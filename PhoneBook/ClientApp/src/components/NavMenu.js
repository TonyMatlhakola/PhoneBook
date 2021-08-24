import React from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";
const NavMenu = () => {
  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <Container>
          <NavbarBrand tag={Link} to="/">
            PhoneBooks
          </NavbarBrand>
          <NavbarToggler className="mr-2" />
          <Collapse
            className="d-sm-inline-flex flex-sm-row-reverse"
            navbar
          >
            <ul className="navbar-nav flex-grow">
              <NavItem></NavItem>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
export default NavMenu;
