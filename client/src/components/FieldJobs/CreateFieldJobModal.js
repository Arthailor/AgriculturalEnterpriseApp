import { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { useSelector } from 'react-redux'
import { createFieldJob } from '../../http/modelAPI'

export default function CreateFieldJobModal({ show, onHide, reload }) {

    const [employeeid, setEmployeeId] = useState('')
    const [fieldid, setFieldId] = useState('')

    const { fields } = useSelector((state) => {
        return state.fields;
    });
    const { employees } = useSelector((state) => {
        return state.employees;
    });

    const addFieldJob = async () => {
        try {
            let data;
            data = await createFieldJob(employeeid, fieldid).then(() => {
                onHide('')
                setEmployeeId('')
                setFieldId('')
                reload()
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
                    Assign employee to field
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Select className="mt-2" value={employeeid} onChange={e => {setEmployeeId(e.target.value)}}>
                        <option value="">Choose employee</option>
                        {employees.map(e =>
                            <option key={e.id} value={e.id}>{e.name} - {e.address}</option>
                        )}
                    </Form.Select>
                    <Form.Select className="mt-2" value={fieldid} onChange={e => {setFieldId(e.target.value)}}>
                        <option value="">Choose field</option>
                        {fields.map(f =>
                            <option key={f.id} value={f.id}>{f.name}</option>
                        )}
                    </Form.Select>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                {employeeid === '' || fieldid === '' ?
                    <Button variant="outline-success" disabled>Assign</Button>
                    :
                    <Button variant="outline-success" onClick={addFieldJob}>Assign</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}