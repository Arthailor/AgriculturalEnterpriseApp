import React, { useState } from 'react'
import { ListGroup, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { deletePasture } from '../../http/modelAPI'
import { setSelected, setTotalCount } from '../../store/pasturesSlice'
import UpdateAnimalModal from './UpdatePastureModal'

export default function PasturesList({ pastures, reload }) {

    const { totalCount } = useSelector((state) => {
        return state.pastures;
    })
    const delPasture = (id) => {
        deletePasture(id).finally(() => handleTotalCount(totalCount-1))
    }

    const dispatch = useDispatch();
    
    const handleSelected = (t) => {
        dispatch(setSelected(t))
    }

    const handleTotalCount = (c) => {
        dispatch(setTotalCount(c))
    }

    const [updateAnimalVisible, setUpdateAnimalVisible] = useState(false)

    return (
        <div>
            {pastures.length === 0 ?
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
                    {pastures.map(p =>
                        <ListGroup.Item
                            key={p.id}
                            className="d-flex justify-content-between"
                        >
                            <div style={{ display: 'flex', alignItems: "center" }}>
                                <p>Id:<br/>{p.id}</p>
                            </div>
                            <div>
                                <Button className="m-1 " variant="outline-warning" onClick={() => {handleSelected(p); setUpdateAnimalVisible(true)}}>Update</Button>
                                <Button className="m-1 " variant="outline-danger" onClick={() => {delPasture(p.id)}}>Delete</Button>
                            </div>
                        </ListGroup.Item>
                    )}
                    </ListGroup>
                    <UpdateAnimalModal show={updateAnimalVisible} onHide={() => setUpdateAnimalVisible(false)} reload = {reload}/>
                </div>
            }
        </div>
    )
}
