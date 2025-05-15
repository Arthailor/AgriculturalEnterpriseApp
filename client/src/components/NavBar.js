import React from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Image from 'react-bootstrap/Image'
import { NavLink } from 'react-router-dom';
import { MAIN_ROUTE } from '../utils/consts';
import { Button } from 'react-bootstrap';
import { useSelector } from 'react-redux';


export default function NavBar() {

  const { name } = useSelector((state) => {
    return state.page;
  })

  return (
    <Navbar bg="primary" data-bs-theme="dark">
      <Container>
        <Nav style={{color:'white', fontWeight:'bold'}}>{name}</Nav>
        <Nav className="ml-auto" style={{ color: 'white' }}>
          <Button variant={"primary"}>
            <NavLink to={MAIN_ROUTE}><Image width ="35" src="./arrow.ico" fluid/></NavLink>
          </Button>
        </Nav>
      </Container>
    </Navbar>
  )
}
