import { useEffect, useState } from 'react'
import { Container, Row, Col, Button, Form } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { setFieldequipment } from '../store/fieldequipmentSlice';
import { setFields } from '../store/fieldsSlice';
import { setEquipment } from '../store/equipmentSlice';
import { setName } from '../store/pageSlice';
import { fetchEmployees, fetchEquipment, fetchFieldEquipment, fetchFieldJobs, fetchFields } from '../http/modelAPI';
import FieldJobsList from '../components/FieldJobs/FieldJobsList';
import CreateFieldJobModal from '../components/FieldJobs/CreateFieldJobModal';
import FieldEquipmentList from '../components/FieldEquipment/FieldEquipmentList';
import CreateFieldEquipmentModal from '../components/FieldEquipment/CreateFieldEquipmentModal';

export default function EquipmentOnFieldsMenu() {

    const { fieldequipment } = useSelector((state) => {
        return state.fieldequipment;
    });
    const { fields } = useSelector((state) => {
        return state.fields;
    });
    const { equipment } = useSelector((state) => {
        return state.equipment;
    });

    const [selectedEquipment, setSelectedEquipment] = useState("")
    const [selectedField, setSelectedField] = useState("")
    const [selFieldequipment, setSelFieldequipment] = useState([])

    const dispatch = useDispatch();

    dispatch(setName('Equipment on fields'))

    const handleFieldEquipment = (e) => {
        dispatch(setFieldequipment(e))
    }
    const handleFields = (f) => {
        dispatch(setFields(f))
    }
    const handleEquipment = (e) => {
        dispatch(setEquipment(e))
    }

    const loadFieldEquipment = () => {
        fetchFieldEquipment().then(data => {
            handleFieldEquipment(data)
        })
    }
    const loadFields = () => {
        fetchFields(1, 9999).then(data => {
            handleFields(data.rows)
        })
    }
    const loadEquipment = () => {
        fetchEquipment(1, 9999).then(data => {
            handleEquipment(data.rows)
        })
    }

    useEffect(() => {
        loadFieldEquipment()
        loadFields()
        loadEquipment()
    }, [])

    useEffect(() => {
        updateSelFieldEquipment();
    }, [selectedField, selectedEquipment, fieldequipment]);


    const updateSelFieldEquipment = () => {
    let filtered = fieldequipment;

    if (selectedField !== "") {
        filtered = filtered.filter(eq => eq.fieldId === selectedField);
    }

    if (selectedEquipment !== "") {
        filtered = filtered.filter(eq => eq.equipmentId === selectedEquipment);
    }

    if (selectedField === "" && selectedEquipment === "") {
        filtered = [];
    }

    setSelFieldequipment(filtered);
};


    const [createFieldEquipmentVisible, setCreateFieldEquipmentVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={2}>
                    <Form>
                        <Form.Select className="mt-2" value={selectedField} onChange={e => {setSelectedField(e.target.value); updateSelFieldEquipment()}}>
                            <option value="">Choose field</option>
                            {fields.map(f =>
                                <option key={f.id} value={f.id}>{f.name}</option>
                            )}
                        </Form.Select>
                        <Form.Select className="mt-2" value={selectedEquipment} onChange={e => {setSelectedEquipment(e.target.value); updateSelFieldEquipment()}}>
                            <option value="">Choose equipment</option>
                            {equipment.map(e =>
                                <option key={e.id} value={e.id}>{e.name} ({e.dateBought.split("T")[0]})</option>
                            )}
                        </Form.Select>
                    </Form>
                </Col>
                <Col md={8} className="mt-2">
                    <FieldEquipmentList fieldequipment = {selFieldequipment} fields = {fields} equipment = {equipment} reload = {a=> {loadFieldEquipment()}}/>
                </Col>
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreateFieldEquipmentVisible(true)}>Assign equipment to field</Button>
                </Col>
            </Row>
            <CreateFieldEquipmentModal show={createFieldEquipmentVisible} onHide={() => setCreateFieldEquipmentVisible(false)} reload={a=> {loadFieldEquipment()}}/>
        </Container>
    )
}