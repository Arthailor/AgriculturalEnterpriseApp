import { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { createCrop, createField } from '../../http/modelAPI'
import { setPage, setTotalCount as setFieldsTotalCount } from '../../store/fieldsSlice'
import { setTotalCount as setCropsTotalCount } from '../../store/cropsSlice'
import { useDispatch, useSelector } from 'react-redux'

export default function CreateFieldModal({ show, onHide }) {

    const { totalCount: fieldsTotalCount } = useSelector((state) => {
        return state.fields;
    })
    const { totalCount: cropsTotalCount } = useSelector((state) => {
        return state.crops;
    })

    const [fieldname, setFieldName] = useState('')
    const [cultivatedarea, setCultivatedArea] = useState('')
    const [uncultivatedarea, setUncultivatedArea] = useState('')
    const [cropid, setCropId] = useState('')
    const [cropname, setCropName] = useState('')
    const [amount, setAmount] = useState('')

    const dispatch = useDispatch();

    const handleFieldsTotalCount = (c) => {
        dispatch(setFieldsTotalCount(c))
    }
    const handleCropsTotalCount = (c) => {
        dispatch(setCropsTotalCount(c))
    }

    const handlePage = (p) => {
        dispatch(setPage(p))
    }

    const addField = async () => {
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
            let createdCrop = await createCrop(crop);
            setCropName('')
            setAmount('')
            handleCropsTotalCount(cropsTotalCount+1)
            console.log(createdCrop.id)
            let createdField = await createField(createdCrop.id, field).then(() => {
                onHide('')
                setFieldName('')
                setCultivatedArea('')
                setUncultivatedArea('')
                setCropId('')
                handleFieldsTotalCount(fieldsTotalCount+1)
                handlePage(1)
            })
        } catch (e) {
            alert(e.response.data.message)
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
                    Add field
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
                    <Button variant="outline-success" disabled>Add</Button>
                    :
                    <Button variant="outline-success" onClick={addField}>Add</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}