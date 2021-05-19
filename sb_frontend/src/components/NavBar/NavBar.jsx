import React from "react";
import "./NavBar.css";
import {
  Navbar,
  Nav,
  NavItem,
  FormControl,
  Button,
  Form,
  NavDropdown,
} from "react-bootstrap";
import logo from "../../logos/logo.png";

const navigation = (props) => {
  return (
    <Navbar fixed="top" bg="dark" variant="dark" expand="lg">
      <Navbar.Brand href="/">
        <img
          alt=""
          src={logo}
          width="30"
          height="30"
          className="d-inline-block align-top"
        />
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="navbarScroll" />
      <Navbar.Collapse id="navbarScroll">
        <Nav className="ml.auto" navbarScroll>
          <NavItem>
            <Nav.Link onCollapse="" href="/">
              Home
            </Nav.Link>
          </NavItem>
          <NavDropdown title="Series" id="collasible-nav-dropdown">
            <NavDropdown.Item href="/series">General</NavDropdown.Item>
            <NavDropdown.Item href="/allstarteams">
              Equipos "Todos Estrella"
            </NavDropdown.Item>
          </NavDropdown>
          <NavItem>
            <Nav.Link href="/players">Jugadores</Nav.Link>
          </NavItem>
          <NavItem>
            <Nav.Link href="/teams">Equipos</Nav.Link>
          </NavItem>
          <NavItem>
            <Nav.Link href="/games">Juegos</Nav.Link>
          </NavItem>
          <NavItem>
            <Nav.Link href="/directors">Directores</Nav.Link>
          </NavItem>
        </Nav>
        <Form inline className="ml-auto" navbarScroll>
          <FormControl type="text" placeholder="Search" className="mr-sm-2" />
          <Button variant="outline-info">Search</Button>
        </Form>
      </Navbar.Collapse>
    </Navbar>
  );
};

export default navigation;
