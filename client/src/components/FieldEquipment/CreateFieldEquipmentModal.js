import { useState } from 'react'
import { Button, Form, Modal } from 'react-bootstrap'
import { useSelector } from 'react-redux'
import { createFieldEquipment } from '../../http/modelAPI'

export default function CreateFieldEquipmentModal({ show, onHide, reload }) {

    const [equipmentid, setEquipmentId] = useState('')
    const [fieldid, setFieldId] = useState('')

    const { fields } = useSelector((state) => {
        return state.fields;
    });
    const { equipment } = useSelector((state) => {
        return state.equipment;
    });

    const addFieldEquipment = async () => {
        try {
            let data;
            data = await createFieldEquipment(equipmentid, fieldid).then(() => {
                onHide('')
                setEquipmentId('')
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
                    Assign equipment to field
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Select className="mt-2" value={equipmentid} onChange={e => {setEquipmentId(e.target.value)}}>
                        <option value="">Choose equipment</option>
                        {equipment.map(e =>
                            <option key={e.id} value={e.id}>{e.name} - {e.dateBought.split("T")[0]}</option>
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
                {equipmentid === '' || fieldid === '' ?
                    <Button variant="outline-success" disabled>Assign</Button>
                    :
                    <Button variant="outline-success" onClick={addFieldEquipment}>Assign</Button>
                }
            </Modal.Footer>
        </Modal>
    )
}