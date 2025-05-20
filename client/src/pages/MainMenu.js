import React from 'react'
import { Container, Form, Card, Button, Image } from 'react-bootstrap'
import { NavLink } from 'react-router-dom';
import { ANIMALS_AND_PASTURES_ROUTE, CROPS_AND_FIELDS_ROUTE } from '../utils/consts';
import { setName } from '../store/pageSlice';
import { useDispatch } from 'react-redux';

export default function MainMenu() {

  const dispatch = useDispatch();
  dispatch(setName('Fields menu'))

  return (
    <div>
        <Container
          className="d-flex justify-content-center align-items-center"
          style={{ height: window.innerHeight - 54 }}
        >
          <Card style={{ width: 600 }} className="p-5">
            <h2 className="m-auto">Main menu</h2>
            <Form className="d-flex flex-column">
              <NavLink to={ANIMALS_AND_PASTURES_ROUTE} className="mt-3" style={{ textDecoration: 'none' }}>
                <Button className="d-flex justify-content-between" variant={"outline-primary"} style={{ width: "100%" }}>
                  <Image width="20" src="./cow.png" fluid />
                  <div style={{ marginRight: 20 }}>Animals and pastures</div>
                  <div></div>
                </Button>
              </NavLink>
              <NavLink to={CROPS_AND_FIELDS_ROUTE} className="mt-3" style={{ textDecoration: 'none' }}>
                <Button className="d-flex justify-content-between" variant={"outline-primary"} style={{ width: "100%" }}>
                  <Image width="20" src="./crops.png" fluid />
                  <div style={{ marginRight: 20 }}>Crops and fields</div>
                  <div></div>
                </Button>
              </NavLink>
            </Form>
          </Card>
        </Container>
    </div>
  )
}
