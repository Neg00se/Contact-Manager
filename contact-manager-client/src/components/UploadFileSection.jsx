import React, { useState } from "react";
import { Button, Form, Row, Col } from "react-bootstrap";
import axios from "axios";

const UploadFileSection = ({ file, setFile, forceUpdate }) => {
  const handleChange = async (e) => {
    e.preventDefault();
    setFile(e.target.files[0]);
  };

  const handleFileUpload = async (e) => {
    e.preventDefault();

    const formData = new FormData();

    if (file) {
      formData.append("file", file);
    }

    try {
      await axios.post("/api/Contact", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      forceUpdate;
    } catch (error) {
      console.log(error.message);
    }
  };

  return (
    <Row>
      <Col>
        <Form>
          <Form.Group controlId="formFileLg" className="mb-3">
            <Form.Label className="fs-2">Upload your csv file</Form.Label>
            <Form.Control
              onChange={handleChange}
              accept=".csv"
              type="file"
              size="lg"
            />
          </Form.Group>

          <Button
            className="btn-success btn-lg my-3 w-50"
            onClick={handleFileUpload}
          >
            Upload
          </Button>
        </Form>
      </Col>
    </Row>
  );
};

export default UploadFileSection;
