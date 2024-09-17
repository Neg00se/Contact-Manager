import axios from "axios";
import React, { useState } from "react";
import { Button, FormCheck, FormControl } from "react-bootstrap";

const Contact = ({ contact }) => {
  const [name, setName] = useState(contact.name);
  const [dob, setDob] = useState(contact.dob);
  const [married, setMarried] = useState(contact.married);
  const [phone, setPhone] = useState(contact.phone);
  const [salary, setSalary] = useState(contact.salary);

  const [edit, setEdit] = useState(false);

  const handleEdit = (e) => {
    e.preventDefault();
    setEdit(true);
  };

  const handleNameChange = (e) => {
    setName(e.target.value);
  };

  const handleDobChange = (e) => setDob(e.target.value);
  const handleMarriedChange = (e) => setMarried(!married);
  const handlePhoneChange = (e) => setPhone(e.target.value);
  const handleSalaryChange = (e) => setSalary(e.target.value);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updatedContact = {
      id: contact.id,
      name,
      dob,
      married,
      phone,
      salary,
    };
    try {
      await axios.put("/api/Contact", updatedContact);
      setEdit(false);
    } catch (error) {
      console.log(error.message);
    }
  };

  const handleDelete = async (e) => {
    try {
      await axios.delete(`/api/Contact/${contact.id}`);
    } catch (error) {
      console.onChange(error.message);
    }
  };

  return (
    <tr>
      <th scope="row">{contact.id}</th>
      <td>
        <FormControl
          plaintext
          readOnly={edit ? false : true}
          value={name}
          onChange={handleNameChange}
        />
      </td>
      <td>
        <FormControl
          type="date"
          plaintext
          readOnly={edit ? false : true}
          value={dob}
          onChange={handleDobChange}
        />
      </td>
      <td>
        <FormCheck
          readOnly={edit ? false : true}
          checked={married}
          onChange={handleMarriedChange}
        />
      </td>
      <td>
        <FormControl
          type="tel"
          plaintext
          readOnly={edit ? false : true}
          value={phone}
          onChange={handlePhoneChange}
        />
      </td>
      <td>
        <FormControl
          type="number"
          plaintext
          readOnly={edit ? false : true}
          value={salary}
          onChange={handleSalaryChange}
        />
      </td>

      <td>
        {edit ? (
          <Button onClick={handleSubmit}>Save</Button>
        ) : (
          <>
            <Button className="m-1" onClick={handleEdit}>
              Edit
            </Button>
            <Button onClick={handleDelete} className="m-1 btn-danger">
              Delete
            </Button>
          </>
        )}
      </td>
    </tr>
  );
};

export default Contact;
