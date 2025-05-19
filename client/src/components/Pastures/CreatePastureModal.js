import React, { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { createAnimal } from '../../http/modelAPI'
import { setPage, setTotalCount } from '../../store/animalsSlice'
import { useDispatch, useSelector } from 'react-redux'

export default function CreateAnimalModal({ show, onHide }) {
    const { totalCount } = useSelector((state) => {
        return state.animals;
    })
    const [name, setName] = useState('')
    const [amount, setAmount] = useState('')
    const [pastureid, setPastureId] = useState('')

    const dispatch = useDispatch();

    const handleTotalCount = (c) => {
        dispatch(setTotalCount(c))
    }

    const handlePage = (n) => {
        dispatch(setPage(n))
    }

    const addAnimal = async () => {

        try {
            const animal = {
                Amount: amount,
                Name: name
            }
            let data;
            data = await createAnimal(pastureid, animal).then(() => {
                onHide('')
                setName('')
                setAmount('')
                setPastureId('')
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
                    Add animal
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
                    <Form.Select className="mt-2" value={pastureid} onChange={e => setPastureId(e.target.value)}>
                        <option value=''>Select pasture</option>
                        <option value='66666666-6666-6666-6666-666666666666'>Pasture 1</option>
                        {/* {classes.map(cls =>
                            <option value={cls.class_id}>{cls.name}</option>
                        )} */}
                    </Form.Select>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {name === '' || amount === '' || pastureid === '' ?
                    <Button variant="outline-success" disabled>Add</Button>
                    :
                    <Button variant="outline-success" onClick={addAnimal}>Add</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
