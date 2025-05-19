import React, { useEffect, useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { updatePasture } from '../../http/modelAPI'
import { useSelector } from 'react-redux';

export default function UpdatePastureModal({ show, onHide, reload }) {

    const { selected } = useSelector((state) => {
        return state.pastures;
    })

    const [name, setName] = useState('')
    const [area, setArea] = useState('')

    useEffect(() => {
    if (selected) {
        setName(selected.name || '')
        setArea(selected.area || '')
    }
}, [selected])

    const updtPasture = async () => {

        try {
            const pasture = {
                Name: name,
                Area: area
            }
            let data;
            data = await updatePasture(selected.id, pasture).then(() => {
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
                    Update pasture
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control className="mt-2" placeholder={"Name"} value={name} onChange={e => setName(e.target.value)} />
                    <Form.Control className="mt-2" placeholder={"Area"} value={area} onChange={e => setArea(prev => {
                                                                                                                            let value = e.target.value.replace(/[^0-9.]/g, "");
                                                                                                                            const parts = value.split(".");
                                                                                                                            if (parts.length > 2) {
                                                                                                                                value = parts[0] + "." + parts.slice(1).join("");
                                                                                                                            }
                                                                                                                            return value;})} />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {name === '' || area === '' ?
                    <Button variant="outline-success" disabled>Update</Button>
                    :
                    <Button variant="outline-success" onClick={updtPasture}>Update</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
