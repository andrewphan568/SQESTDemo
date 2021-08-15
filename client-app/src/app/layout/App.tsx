import React, { useEffect, useState } from 'react';
import './styles.css';
import NavBar from './NavBar';
import MoistureContentDetails from '../../features/worksheet/moistureContentDetails';
import { Container } from 'semantic-ui-react';
function App() {
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <MoistureContentDetails />
      </Container>

    </>
  );
}

export default App;
