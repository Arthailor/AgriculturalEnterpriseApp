import { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { createRepair } from '../../http/modelAPI'
import { setTotalCount } from '../../store/repairsSlice'
import { useDispatch, useSelector } from 'react-redux'

export default function CreateRepairModal({ show, onHide, employees }) {
    
    const { selectedEquipment, totalCount } = useSelector((state) => {
        return state.repairs;
    })

    const [employeeid, setEmployeeId] = useState('')
    const [dateofbreakage, setDateOfBreakage] = useState('')
    const [dateofrepair, setDateOfRepair] = useState('')
    const [causeofbreakage, setCauseOfBreakage] = useState('')

    const dispatch = useDispatch();

    const handleTotalCount = (c) => {
        dispatch(setTotalCount(c))
    }

    const addRepair = async () => {

        try {
            const repair = {
                DateOfBreakage: dateofbreakage,
                DateOfRepair: dateofrepair,
                CauseOfBreakage: causeofbreakage
            }
            let data;
            data = await createRepair(selectedEquipment.id, employeeid, repair).then(() => {
                onHide('')
                setEmployeeId('')
                setDateOfBreakage('')
                setDateOfRepair('')
                setCauseOfBreakage('')
                handleTotalCount(totalCount+1)
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
                    Add repair
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control type="date" className="mt-2" placeholder={"Date of breakage"} value={dateofbreakage} onChange={e => setDateOfBreakage(e.target.value)} />
                    <Form.Control type="date" className="mt-2" placeholder={"Date of repair"} value={dateofrepair} onChange={e => setDateOfRepair(e.target.value)} />
                    <Form.Control className="mt-2" placeholder={"Cause of breakage"} value={causeofbreakage} onChange={e => setCauseOfBreakage(e.target.value)} />
                    <Form.Select className="mt-2" value={employeeid} onChange={e => setEmployeeId(e.target.value)}>
                        <option value=''>Select employee</option>
                        {employees.map(e =>
                            <option value={e.id}>{e.name}</option>
                        )}
                    </Form.Select>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {dateofbreakage === '' || dateofrepair === '' || causeofbreakage === '' || employeeid === '' ?
                    <Button variant="outline-success" disabled>Add</Button>
                    :
                    <Button variant="outline-success" onClick={addRepair}>Add</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}
