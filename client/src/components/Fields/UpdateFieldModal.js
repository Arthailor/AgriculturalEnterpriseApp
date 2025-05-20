import React, { useEffect, useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { updateCrop, updateField } from '../../http/modelAPI'
import { useSelector } from 'react-redux';

export default function UpdateFieldModal({ show, onHide, reload }) {

    const { selected: selectedField } = useSelector((state) => {
        return state.fields;
    })
    const { selected: selectedCrop } = useSelector((state) => {
        return state.crops;
    })

    const [fieldname, setFieldName] = useState('')
    const [cultivatedarea, setCultivatedArea] = useState('')
    const [uncultivatedarea, setUncultivatedArea] = useState('')
    const [cropname, setCropName] = useState('')
    const [amount, setAmount] = useState('')

    useEffect(() => {
    if (selectedField) {
        setFieldName(selectedField.name || '')
        setCultivatedArea(selectedField.cultivatedArea || '')
        setUncultivatedArea(selectedField.uncultivatedArea || '')
    }
    }, [selectedField])

    useEffect(() => {
    if (selectedCrop) {
        setCropName(selectedCrop.name || '')
        setAmount(selectedCrop.amount || '')
    }
    }, [selectedCrop])

    const updtField = async () => {
        try {
            const crop = {
                Name: cropname,
                Amount: amount
            }
            const field = {
                Name: fieldname,
                CultivatedArea: cultivatedarea,
                UncultivatedArea: uncultivatedarea
            }
            let data;
            data = await updateField(selectedField.id, field).then(() => {
                reload()
            })
            data = await updateCrop(selectedCrop.id, crop).then(() => {
                onHide('')
                reload()
            })
        } catch (e) {
            alert(e.response?.data?.message || e.message || "Unknown error");
        }
    }

    return (
        <Modal
            show={show}
            onHide={onHide}
            size="lg"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Update field
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control className="mt-2" placeholder={"Field Name"} value={fieldname} onChange={e => setFieldName(e.target.value)} />
                    <Form.Control className="mt-2" placeholder={"Cultivated Area"} value={cultivatedarea} onChange={e => setCultivatedArea(prev => {
                                                                                                                            let value = e.target.value.replace(/[^0-9.]/g, "");
                                                                                                                            const parts = value.split(".");
                                                                                                                            if (parts.length > 2) {
                                                                                                                                value = parts[0] + "." + parts.slice(1).join("");
                                                                                                                            }
                                                                                                                            return value;})} />
                    <Form.Control className="mt-2" placeholder={"Uncultivated Area"} value={uncultivatedarea} onChange={e => setUncultivatedArea(prev => {
                                                                                                                            let value = e.target.value.replace(/[^0-9.]/g, "");
                                                                                                                            const parts = value.split(".");
                                                                                                                            if (parts.length > 2) {
                                                                                                                                value = parts[0] + "." + parts.slice(1).join("");
                                                                                                                            }
                                                                                                                            return value;})} />
                    <Form.Control className="mt-2" placeholder={"Crop Name"} value={cropname} onChange={e => setCropName(e.target.value)} />
                    <Form.Control maxLength="3" className="mt-2" placeholder={"Amount"} value={amount} onChange={e => setAmount(e.target.value.replace(/\D/g, ""))} />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {fieldname === '' || cultivatedarea === '' || uncultivatedarea === '' || cropname === '' || amount === '' ?
                    <Button variant="outline-success" disabled>Update</Button>
                    :
                    <Button variant="outline-success" onClick={updtField}>Update</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
