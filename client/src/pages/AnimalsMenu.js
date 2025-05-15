import React, { useEffect, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { setAnimals, setTotalCount, setPage } from '../store/animalsSlice';
import { fetchAnimals } from '../http/modelAPI';
import Pages from '../components/Pages'
import AnimalsList from '../components/Animals/AnimalsList';
import CreateAnimalModal from '../components/Animals/CreateAnimalModal';
import { setName } from '../store/pageSlice';

export default function EmployeeListMenu() {
    const { animals, page, totalCount, limit } = useSelector((state) => {
        return state.animals;
    })
    const dispatch = useDispatch();
    
    dispatch(setName('Animals'))

    const handleAnimals = (t) => {
        dispatch(setAnimals(t))
    }
    
    const handleTotalCount = (c) => {
      dispatch(setTotalCount(c))
    }
    const handlePage = (n) => {
      dispatch(setPage(n))
    }
    
    const loadAnimals = () => {
        fetchAnimals(page, limit).then(data => {
          handleAnimals(data.rows)
          handleTotalCount(data.count)
        })
      }

      useEffect(() => {
        loadAnimals()
      }, [page, totalCount])

    const [createAnimalVisible, setCreateAnimalVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={3}>
                    <Button variant={"outline-success"} className="mt-4 p-2" onClick={() => setCreateAnimalVisible(true)}>Add animal</Button>
                    <Pages totalCount={totalCount} limit={limit} page={page} handlePage={(p) => handlePage(p)} />
                </Col>
                <Col md={9} className="mt-2">
                    <AnimalsList animals = {animals} reload = {loadAnimals}/>
                </Col>
            </Row>
            <CreateAnimalModal show={createAnimalVisible} onHide={() => setCreateAnimalVisible(false)}/>
        </Container>
    )
}