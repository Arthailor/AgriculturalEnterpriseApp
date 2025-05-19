import React, { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { createPasture } from '../../http/modelAPI'
import { setPage, setTotalCount } from '../../store/pasturesSlice'
import { useDispatch, useSelector } from 'react-redux'

export default function CreatePastureModal({ show, onHide }) {
    const { totalCount } = useSelector((state) => {
        return state.pastures;
    })
    const [name, setName] = useState('')
    const [area, setArea] = useState('')
    const [fieldid, setFieldId] = useState('')

    const dispatch = useDispatch();

    const handleTotalCount = (c) => {
        dispatch(setTotalCount(c))
    }

    const handlePage = (n) => {
        dispatch(setPage(n))
    }

    const addPasture = async () => {
        try {
            const pasture = {
                Name: name,
                Area: area
            }
            let data;
            data = await createPasture(fieldid, pasture).then(() => {
                onHide('')
                setName('')
                setArea('')
                setFieldId('')
                handleTotalCount(totalCount+1)
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
                    Add pasture
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
                    <Form.Select className="mt-2" value={fieldid} onChange={e => setFieldId(e.target.value)}>
                        <option value=''>Select field</option>
                        <option value='44444444-4444-4444-4444-444444444444'>Field placeholder</option>
                    </Form.Select>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {name === '' || area === '' || fieldid === '' ?
                    <Button variant="outline-success" disabled>Add</Button>
                    :
                    <Button variant="outline-success" onClick={addPasture}>Add</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
