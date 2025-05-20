import React, { useEffect, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { setAnimals, setTotalCount as setAnimalsTotalCount, setPage as setAnimalsPage} from '../store/animalsSlice';
import { fetchAnimals, fetchFields, fetchPastures } from '../http/modelAPI';
import Pages from '../components/Pages'
import AnimalsList from '../components/Animals/AnimalsList';
import CreateAnimalModal from '../components/Animals/CreateAnimalModal';
import { setName } from '../store/pageSlice';
import PasturesList from '../components/Pastures/PasturesList';
import { setPastures, setTotalCount as setPasturesTotalCount, setPage as setPasturesPage } from '../store/pasturesSlice';
import CreatePastureModal from '../components/Pastures/CreatePastureModal';

export default function AnimalsAndPasturesListMenu() {
    const { animals, page: animalsPage, totalCount: animalsTotalCount, limit: animalsLimit} = useSelector((state) => {
      return state.animals;
    });

    const {pastures, page: pasturesPage, totalCount: pasturesTotalCount, limit: pasturesLimit} = useSelector((state) => {
      return state.pastures;
    });

    const dispatch = useDispatch();
    
    dispatch(setName('Animals and pastures'))

    const handleAnimals = (t) => {
        dispatch(setAnimals(t))
    }
    const handleAnimalsTotalCount = (c) => {
      dispatch(setAnimalsTotalCount(c))
    }
    const handleAnimalsPage = (n) => {
      dispatch(setAnimalsPage(n))
    }

    const handlePastures = (t) => {
        dispatch(setPastures(t))
    }
    const handlePasturesTotalCount = (c) => {
      dispatch(setPasturesTotalCount(c))
    }
    const handlePasturesPage = (n) => {
      dispatch(setPasturesPage(n))
    }

    const [fields, setFields] = useState([])

    useEffect(() => {
      fetchFields(1, 9999).then(data => {
          setFields(data.rows)
      })
    }, [])

    const loadAnimals = () => {
        fetchAnimals(animalsPage, animalsLimit).then(data => {
          handleAnimals(data.rows)
          handleAnimalsTotalCount(data.count)
        })
      }

    useEffect(() => {
      loadAnimals()
    }, [animalsPage, animalsTotalCount, pasturesTotalCount])

    const loadPastures = () => {
        fetchPastures(pasturesPage, pasturesLimit).then(data => {
          handlePastures(data.rows)
          handlePasturesTotalCount(data.count)
        })
      }

    useEffect(() => {
      loadPastures()
    }, [pasturesPage, pasturesTotalCount])

    const [createAnimalVisible, setCreateAnimalVisible] = useState(false)
    const [createPastureVisible, setCreatePastureVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreateAnimalVisible(true)}>Add animal</Button>
                    <Pages totalCount={animalsTotalCount} limit={animalsLimit} page={animalsPage} handlePage={(p) => handleAnimalsPage(p)} />
                </Col>
                <Col md={4} className="mt-2">
                    <AnimalsList animals = {animals} reload = {loadAnimals}/>
                </Col>
                <Col md={4} className="mt-2">
                    <PasturesList pastures = {pastures} reload = {loadPastures}/>
                </Col>
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreatePastureVisible(true)}>Add pasture</Button>
                    <Pages totalCount={pasturesTotalCount} limit={pasturesLimit} page={pasturesPage} handlePage={(p) => handlePasturesPage(p)} />
                </Col>
            </Row>
            <CreateAnimalModal show={createAnimalVisible} onHide={() => setCreateAnimalVisible(false)} pastures={pastures}/>
            <CreatePastureModal show={createPastureVisible} fields={fields} onHide={() => setCreatePastureVisible(false)}/>
        </Container>
    )
}