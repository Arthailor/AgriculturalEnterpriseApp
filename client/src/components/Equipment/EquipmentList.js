import React from 'react'
import { Accordion, Button, ListGroup } from 'react-bootstrap'
import { deleteEquipment, deleteRepair } from '../../http/modelAPI';
import { useDispatch } from 'react-redux';
import { setSelectedEquipment } from '../../store/repairsSlice';

export default function EquipmentList({ equipment, repairs, employees, reload, show}) {
    const delEquipment = (eId) => {
        deleteEquipment(eId).finally(() => reload());
    }

    const delRepair = (rId) => {
        deleteRepair(rId).finally(() => reload());
    }

    const dispatch = useDispatch();

    const handleSelectedEquipment = (e) => {
        dispatch(setSelectedEquipment(e))
    }

    return (
        <div>
            {equipment.length === 0 ?
                <ListGroup>
                    <ListGroup.Item
                        className="d-flex justify-content-between"
                        key={1}
                    >
                        Empty list
                    </ListGroup.Item>
                </ListGroup>
                :
                <Accordion defaultActiveKey="0">
                    {equipment.map(e =>
                        <Accordion.Item key={e.id} eventKey={e.id}>
                            <Accordion.Header className="d-flex justify-content-between">
                                <div>{e.name} - ({e.dateBought.split("T")[0]})</div>
                                <div>
                                    <Button className="m-1" variant="outline-danger" onClick={() => { delEquipment(e.id) }}>Delete</Button>
                                </div>
                            </Accordion.Header>
                            <Accordion.Body>
                                {repairs.some(rep => rep.equipmentId === e.id) ?
                                    <div>
                                        <Button className="m-1 " variant="outline-success" onClick={() => {
                                            handleSelectedEquipment(e);
                                            show();
                                        }}>Add</Button>
                                        <ListGroup>Repair Logs:
                                            {repairs.filter(rep => rep.equipmentId === e.id).map(r => {
                                                const employee = employees.find(e => e.id === r.employeeId)
                                                return (
                                                    <ListGroup.Item key={r.id} className='d-flex justify-content-between'>
                                                        <div>
                                                            <p>
                                                                Date of breakage: {r.dateOfBreakage.split("T")[0]} <br/>
                                                                Date of repair: {r.dateOfRepair.split("T")[0]} <br/>
                                                                Cause of breakage: {r.causeOfBreakage} <br/>
                                                                Responsible: {employee.name}
                                                            </p>
                                                        </div>
                                                        <Button className="m-1" variant="outline-danger" onClick={() => { delRepair(r.id) }}>Delete</Button>
                                                    </ListGroup.Item>
                                                );
                                            })}
                                        </ListGroup>
                                    </div>
                                    :
                                    <div>
                                        <Button className="m-1 " variant="outline-success" onClick={() => {
                                            handleSelectedEquipment(e);
                                            show();
                                        }}>Add</Button>
                                        <ListGroup>Repair Logs: <ListGroup.Item key={1}>none</ListGroup.Item></ListGroup>
                                    </div>
                                }
                            </Accordion.Body>
                        </Accordion.Item>
                    )}
                </Accordion>
            }
        </div>
    )
}
