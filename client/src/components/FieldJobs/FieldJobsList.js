import { ListGroup, Button } from 'react-bootstrap'
import { deleteFieldJob } from '../../http/modelAPI';

export default function FieldJobsList({ fieldjobs, fields, employees, reload }) {

    const delFieldJob = (eid, fid) => {
        deleteFieldJob(eid, fid).finally(() => reload())
    }
    
    return (
        <div>
            {fieldjobs.length === 0 ?
                <ListGroup>
                    <ListGroup.Item
                        className="d-flex justify-content-between"
                    >
                        Empty list
                    </ListGroup.Item>
                </ListGroup>
                :
                <div>
                    <ListGroup>
                    {fieldjobs.map(j =>{
                        const field = fields.find(f => f.id === j.fieldId);
                        const employee = employees.find(e => e.id === j.employeeId)
                        return(
                            <ListGroup.Item
                            key={j.id}
                            className="d-flex justify-content-between"
                            >
                                <div style={{ display: 'flex', alignItems: "center" }}>
                                    <p>{employee.name} {"-->"} {field.name}</p>
                                </div>
                                <div>
                                    <Button className="m-1 " variant="outline-danger" onClick={() => {delFieldJob(employee.id, field.id)}}>Delete</Button>
                                </div>
                            </ListGroup.Item>
                        )
                    }
                    )}
                    </ListGroup>
                </div>
            }
        </div>
    )
}
