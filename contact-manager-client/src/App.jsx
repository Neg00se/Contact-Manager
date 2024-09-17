import { useEffect, useReducer, useState } from "react";
import "./App.css";
import UploadFileSection from "./components/UploadFileSection";
import ContactTable from "./components/ContactTable";
import axios from "axios";

function App() {
  const [contacts, setContacts] = useState([]);
  const [file, setFile] = useState(null);
  const [, forceUpdate] = useReducer((x) => x + 1, 0);

  const loadContacts = async () => {
    try {
      const response = await axios.get("/api/Contact");
      setContacts(response.data);
    } catch (error) {
      console.log(error.message);
    }
  };

  useEffect(() => {
    loadContacts();
  }, []);

  return (
    <>
      <UploadFileSection
        file={file}
        setFile={setFile}
        forceUpdate={forceUpdate}
      />
      <ContactTable contacts={contacts} />
    </>
  );
}

export default App;
