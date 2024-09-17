import axios from "axios";
import React, { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import Contact from "./Contact";

const ContactTable = ({ contacts }) => {
  return (
    <Table striped bordered hover>
      <thead>
        <tr style={{ cursor: "pointer" }}>
          <th scope="col">Contact Id</th>
          <th scope="col">Name</th>
          <th scope="col">Dob</th>
          <th scope="col">Married</th>
          <th scope="col">Phone</th>
          <th scope="col">Salary</th>
          <th scope="col">Operations</th>
        </tr>
      </thead>
      <tbody>
        {contacts.map((contact) => (
          <Contact key={contact.id} contact={contact} />
        ))}
      </tbody>
    </Table>
  );
};

export default ContactTable;
