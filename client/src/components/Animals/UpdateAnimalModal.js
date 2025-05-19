import React, { useEffect, useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { updateAnimal } from '../../http/modelAPI'
import { useSelector } from 'react-redux';

export default function UpdateAnimalModal({ show, onHide, reload }) {

    const { selected } = useSelector((state) => {
        return state.animals;
    })

    const [name, setName] = useState('')
    const [amount, setAmount] = useState('')

    useEffect(() => {
    if (selected) {
        setName(selected.name || '')
        setAmount(selected.amount || '')
    }
}, [selected])

    const updtAnimal = async () => {

        try {
            const animal = {
                Amount: amount,
                Name: name
            }
            let data;
            data = await updateAnimal(selected.id, animal).then(() => {
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
                    Update animal
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Select className="mt-2" value={name} onChange={e => setName(e.target.value)}>
                        <option value=''>Select type</option>
                        <option value='Овцы'>Овцы</option>
                        <option value='Коровы'>Коровы</option>
                        <option value='Куры'>Куры</option>
                        <option value='Свиньи'>Свиньи</option>
                    </Form.Select>
                    <Form.Control  maxLength="3" className="mt-2" placeholder={"Amount"} value={amount} onChange={e => setAmount(e.target.value.replace(/\D/g, ""))} />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {name === '' || amount === '' ?
                    <Button variant="outline-success" disabled>Update</Button>
                    :
                    <Button variant="outline-success" onClick={updtAnimal}>Update</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
