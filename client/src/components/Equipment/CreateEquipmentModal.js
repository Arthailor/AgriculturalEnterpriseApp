import { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { createEquipment } from '../../http/modelAPI'
import { setPage, setTotalCount } from '../../store/equipmentSlice'
import { useDispatch, useSelector } from 'react-redux'

export default function CreateEquipmentModal({ show, onHide, warehouses }) {
    
    const { totalCount } = useSelector((state) => {
        return state.equipment;
    })
    const [name, setName] = useState('')
    const [datebought, setDateBought] = useState('')
    const [warehouseid, setWarehouseId] = useState('')

    const dispatch = useDispatch();

    const handleTotalCount = (c) => {
        dispatch(setTotalCount(c))
    }

    const handlePage = (n) => {
        dispatch(setPage(n))
    }

    const addEquipment = async () => {

        try {
            const equipment = {
                Name: name,
                DateBought: datebought
            }
            let data;
            data = await createEquipment(warehouseid, equipment).then(() => {
                onHide('')
                setName('')
                setDateBought('')
                setWarehouseId('')
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
                    Add equipment
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Select className="mt-2" value={name} onChange={e => setName(e.target.value)}>
                        <option value=''>Select type</option>
                        <option value='Трактор'>Трактор</option>
                        <option value='Комбайн'>Комбайн</option>
                        <option value='Погрузчик'>Погрузчик</option>
                    </Form.Select>
                    <Form.Control type="date" className="mt-2" placeholder={"Date"} value={datebought} onChange={e => setDateBought(e.target.value)} />
                    <Form.Select className="mt-2" value={warehouseid} onChange={e => setWarehouseId(e.target.value)}>
                        <option value=''>Select warehouse</option>
                        {warehouses.map(w =>
                            <option value={w.id}>Склад: {w.id}</option>
                        )}
                    </Form.Select>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {name === '' || datebought === '' || warehouseid === '' ?
                    <Button variant="outline-success" disabled>Add</Button>
                    :
                    <Button variant="outline-success" onClick={addEquipment}>Add</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
