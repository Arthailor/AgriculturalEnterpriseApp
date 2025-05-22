import { useEffect, useState } from 'react'
import { Container, Row, Col, Button, Form } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { setFieldjobs } from '../store/fieldjobsSlice';
import { setFields } from '../store/fieldsSlice';
import { setEmployees } from '../store/employeesSlice';
import { setName } from '../store/pageSlice';
import { fetchEmployees, fetchFieldJobs, fetchFields } from '../http/modelAPI';
import FieldJobsList from '../components/FieldJobs/FieldJobsList';
import CreateFieldJobModal from '../components/FieldJobs/CreateFieldJobModal';

export default function EmployeesOnFieldsMenu() {

    const { fieldjobs } = useSelector((state) => {
        return state.fieldjobs;
    });
    const { fields } = useSelector((state) => {
        return state.fields;
    });
    const { employees } = useSelector((state) => {
        return state.employees;
    });

    const [selectedField, setSelectedField] = useState("")
    const [selectedEmployee, setSelectedEmployee] = useState("")
    const [selFieldJobs, setSelFieldJobs] = useState([])

    const dispatch = useDispatch();

    dispatch(setName('Employees on fields'))

    const handleFieldJobs = (j) => {
        dispatch(setFieldjobs(j))
    }
    const handleFields = (f) => {
        dispatch(setFields(f))
    }
    const handleEmployees = (e) => {
        dispatch(setEmployees(e))
    }

    const loadFieldJobs = () => {
        fetchFieldJobs().then(data => {
            handleFieldJobs(data)
        })
    }
    const loadFields = () => {
        fetchFields(1, 9999).then(data => {
            handleFields(data.rows)
        })
    }
    const loadEmployees = () => {
        fetchEmployees().then(data => {
            handleEmployees(data)
        })
    }

    useEffect(() => {
        loadFieldJobs()
        loadFields()
        loadEmployees()
    }, [])

    useEffect(() => {
        updateSelFieldJobs();
    }, [selectedField, selectedEmployee, fieldjobs]);


    const updateSelFieldJobs = () => {
    let filtered = fieldjobs;

    if (selectedField !== "") {
        filtered = filtered.filter(job => job.fieldId === selectedField);
    }

    if (selectedEmployee !== "") {
        filtered = filtered.filter(job => job.employeeId === selectedEmployee);
    }

    if (selectedField === "" && selectedEmployee === "") {
        filtered = [];
    }

    setSelFieldJobs(filtered);
};


    const [createFieldJobVisible, setCreateFieldJobVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={2}>
                    <Form>
                        <Form.Select className="mt-2" value={selectedField} onChange={e => {setSelectedField(e.target.value); updateSelFieldJobs()}}>
                            <option value="">Choose field</option>
                            {fields.map(f =>
                                <option key={f.id} value={f.id}>{f.name}</option>
                            )}
                        </Form.Select>
                        <Form.Select className="mt-2" value={selectedEmployee} onChange={e => {setSelectedEmployee(e.target.value); updateSelFieldJobs()}}>
                            <option value="">Choose employee</option>
                            {employees.map(e =>
                                <option key={e.id} value={e.id}>{e.name} - {e.address}</option>
                            )}
                        </Form.Select>
                    </Form>
                </Col>
                <Col md={8} className="mt-2">
                    <FieldJobsList fieldjobs = {selFieldJobs} fields = {fields} employees = {employees} reload = {a=> {loadFieldJobs()}}/>
                </Col>
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreateFieldJobVisible(true)}>Assign employee to field</Button>
                </Col>
            </Row>
            <CreateFieldJobModal show={createFieldJobVisible} onHide={() => setCreateFieldJobVisible(false)} reload={a=> {loadFieldJobs()}}/>
        </Container>
    )
}