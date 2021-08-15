import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './styles.css';
import NavBar from './NavBar';
import MoistureContentDetails from '../../features/worksheet/moistureContentDetails';
import MoistureContentList from '../../features/worksheet/moistureContentList'
import { Container } from 'semantic-ui-react';
function App() {

  const [moistureContents, setMoistureContents] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/moistureContent').then(response => {
      console.log(response);
      setMoistureContents(response.data.value);
    })
  }, [])

  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <MoistureContentList moistureContents={moistureContents} />
      </Container>

    </>
  );
}

export default App;
