import React, { useState } from 'react'
import { ListGroup, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { deleteAnimal } from '../../http/modelAPI'
import { setSelected, setTotalCount } from '../../store/animalsSlice'
import UpdateAnimalModal from './UpdateAnimalModal'

export default function AnimalsList({ animals, reload }) {

    const { totalCount } = useSelector((state) => {
        return state.animals;
    })
    const delAnimal = (id) => {
        deleteAnimal(id).finally(() => handleTotalCount(totalCount-1))
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
            {animals.length === 0 ?
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
                    {animals.map(a =>
                        <ListGroup.Item
                            key={a.id}
                            className="d-flex justify-content-between"
                        >
                            <div style={{ display: 'flex', alignItems: "center" }}>{a.name} - {a.amount} - Pasture 1</div>
                            <div>
                                <Button className="m-1 " variant="outline-warning" onClick={() => {handleSelected(a); setUpdateAnimalVisible(true)}}>Update</Button>
                                <Button className="m-1 " variant="outline-danger" onClick={() => {delAnimal(a.id)}}>Delete</Button>
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
