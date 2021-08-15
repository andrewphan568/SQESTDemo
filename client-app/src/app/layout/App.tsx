import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './styles.css';
import { Route, Switch, useLocation } from 'react-router-dom';
import NavBar from './NavBar';
import MoistureContentList from '../../features/worksheet/moistureContentList'
import MoistureContentDetails from '../../features/worksheet/moistureContentList'
import HomePage from '../../features/home/HomePage';
import NotFoundPage from '../../features/errors/NotFoundPage';
import { Container } from 'semantic-ui-react';
function App() {

  const [moistureContents, setMoistureContents] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/moistureContent').then(response => {
      setMoistureContents(response.data.value);
    })
  }, [])

  const location = useLocation();
  return (
    <>
      <Route exact path='/' component={HomePage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: '7em' }}>
              <Switch>
                <Route exact path='/moistureContentList' component={MoistureContentList} />
                <Route path='/moistureContentLisy/:id' component={MoistureContentDetails} />
                <Route component={NotFoundPage} />
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
}

export default App;
