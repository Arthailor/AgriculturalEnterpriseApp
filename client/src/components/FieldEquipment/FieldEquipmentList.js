import { ListGroup, Button } from 'react-bootstrap'
import { deleteFieldEquipment } from '../../http/modelAPI';

export default function FieldEquipmentList({ fieldequipment, fields, equipment, reload }) {

    const delFieldEquipment = (eid, fid) => {
        deleteFieldEquipment(eid, fid).finally(() => reload())
    }
    
    return (
        <div>
            {fieldequipment.length === 0 ?
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
                    {fieldequipment.map(eq =>{
                        const field = fields.find(f => f.id === eq.fieldId);
                        const equip = equipment.find(e => e.id === eq.equipmentId)
                        return(
                            <ListGroup.Item
                            key={eq.id}
                            className="d-flex justify-content-between"
                            >
                                <div style={{ display: 'flex', alignItems: "center" }}>
                                    <p>{equip.name} ({equip.dateBought.split("T")[0]}) {"-->"} {field.name}</p>
                                </div>
                                <div>
                                    <Button className="m-1 " variant="outline-danger" onClick={() => {delFieldEquipment(equip.id, field.id)}}>Delete</Button>
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
