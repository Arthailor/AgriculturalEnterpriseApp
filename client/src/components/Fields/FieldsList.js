import { useState } from 'react'
import { ListGroup, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { deleteField, deleteCrop } from '../../http/modelAPI'
import { setSelected as setSelectedField, setTotalCount as setFieldsTotalCount } from '../../store/fieldsSlice'
import { setSelected as setSelectedCrop, setTotalCount as setCropsTotalCount } from '../../store/cropsSlice'
import UpdateFieldModal from './UpdateFieldModal'

export default function FieldsList({ fields, crops, reload }) {

    const { totalCount } = useSelector((state) => {
        return state.fields;
    })

    const delField = (f) => {
        console.log(f)
        deleteField(f.id).finally(() => handleFieldsTotalCount(totalCount-1))
        deleteCrop(f.cropId).finally(() => handleCropsTotalCount(totalCount-1))
    }

    const dispatch = useDispatch();
    
    const handleSelectedField = (f) => {
        dispatch(setSelectedField(f))
    }
    const handleFieldsTotalCount = (c) => {
        dispatch(setFieldsTotalCount(c))
    }

    const handleSelectedCrop = (c) => {
        dispatch(setSelectedCrop(c))
    }
    const handleCropsTotalCount = (c) => {
        dispatch(setCropsTotalCount(c))
    }

    const [updateFieldVisible, setUpdateFieldVisible] = useState(false)

    return (
        <div>
            {fields.length === 0 ?
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
                    {fields.map(f =>{
                        const crop = crops.find(c => c.id === f.cropId);
                        return(
                            <ListGroup.Item
                            key={f.id}
                            className="d-flex justify-content-between"
                            >
                                <div style={{ display: 'flex', alignItems: "center" }}>
                                    <p>Name: {f.name}<br/>Cultivated area: {f.cultivatedArea}<br/>Uncultivated area: {f.uncultivatedArea}<br/><br/>Crop: {crop ? crop.name : ''}<br/>Crop amount: {crop ? crop.amount : ''} kg</p>
                                </div>
                                <div>
                                    <Button className="m-1 " variant="outline-warning" onClick={() => {
                                        handleSelectedField(f);
                                        handleSelectedCrop(crop);
                                        setUpdateFieldVisible(true)
                                    }}>Update</Button>
                                    <Button className="m-1 " variant="outline-danger" onClick={() => {delField(f)}}>Delete</Button>
                                </div>
                            </ListGroup.Item>
                        )
                    }
                    )}
                    </ListGroup>
                    <UpdateFieldModal show={updateFieldVisible} onHide={() => setUpdateFieldVisible(false)} reload = {reload}/>
                </div>
            }
        </div>
    )
}
