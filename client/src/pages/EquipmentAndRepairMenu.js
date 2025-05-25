import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Container, Row, Col, Button } from 'react-bootstrap';
import Pages from '../components/Pages';
import { setEquipment, setPage, setTotalCount } from '../store/equipmentSlice';
import EquipmentList from '../components/Equipment/EquipmentList';
import { setName } from '../store/pageSlice';
import { setRepairs } from '../store/repairsSlice';
import { fetchEmployees, fetchEquipment, fetchRepairs, fetchWarehouses } from '../http/modelAPI';
import { setEmployees } from '../store/employeesSlice';
import { setWarehouses } from '../store/warehousesSlice';
import CreateEquipmentModal from '../components/Equipment/CreateEquipmentModal';
import CreateRepairModal from '../components/Repairs/CreateRepairModal';

export default function EquipmentAndRepairListMenu() {

    const { equipment, page: equipmentPage, totalCount: equipmentTotalCount, limit: equipmentLimit} = useSelector((state) => {
        return state.equipment;
    });

    const { repairs, totalCount: repairsTotalCount } = useSelector((state) => {
        return state.repairs;
    });

    const { employees } = useSelector((state) => {
        return state.employees;
    });

    const { warehouses } = useSelector((state) => {
        return state.warehouses;
    });

    const dispatch = useDispatch();

    dispatch(setName('Equipment and repair'))

    const handleEquipment = (e) => {
        dispatch(setEquipment(e))
    }
    const handleRepairs = (r) => {
        dispatch(setRepairs(r))
    }
    const handleEquipmentPage = (p) => {
        dispatch(setPage(p))
    }
    const handleEquipmentTotalCount = (p) => {
        dispatch(setTotalCount(p))
    }
    const handleEmployees = (e) => {
        dispatch(setEmployees(e))
    }
    const handleWarehouses = (w) => {
        dispatch(setWarehouses(w))
    }

    const loadEquipment = () => {
        fetchEquipment(equipmentPage, equipmentLimit).then(data => {
            handleEquipment(data.rows)
            handleEquipmentTotalCount(data.count)
        })
    }
    const loadRepairs = () => {
        fetchRepairs(1, 9999).then(data => {
            handleRepairs(data.rows)
        })
    }
    const loadEmployees = () => {
        fetchEmployees().then(data => {
            handleEmployees(data)
        })
    }
    const loadWarehouses = () => {
        fetchWarehouses().then(data => {
            handleWarehouses(data)
        })
    }

    useEffect(() => {
        loadEmployees()
        loadWarehouses()
    }, [])

    useEffect(() => {
        loadRepairs()
    }, [repairsTotalCount])

    useEffect(() => {
        loadEquipment()
    }, [equipmentPage, equipmentTotalCount])

    const [createEquipmentVisible, setCreateEquipmentVisible] = useState(false)
    const [createRepairVisible, setCreateRepairVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreateEquipmentVisible(true)}>Add equipment</Button>
                    <Pages totalCount={equipmentTotalCount} limit={equipmentLimit} page={equipmentPage} handlePage={(p) => handleEquipmentPage(p)} />
                </Col>
                <Col md={10} className="mt-2">
                    <EquipmentList equipment={equipment} repairs={repairs} employees={employees} reload={a=> {loadEquipment(); loadRepairs()}} show={() => setCreateRepairVisible(true)} />
                </Col>
            </Row>
            <CreateEquipmentModal show={createEquipmentVisible} onHide={() => setCreateEquipmentVisible(false)} warehouses = {warehouses}/>
            <CreateRepairModal show={createRepairVisible} onHide={() => setCreateRepairVisible(false)} employees={employees}/>
        </Container>
    )
}