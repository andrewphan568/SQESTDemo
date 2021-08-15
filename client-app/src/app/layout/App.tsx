import React from 'react';
import './styles.css';
import { Route, Switch } from 'react-router-dom';
import NavBar from './NavBar';
import MoistureContentList from '../../features/worksheet/moistureContentList';
import MoistureContentDetails from '../../features/worksheet/moistureContentDetails';
import HomePage from '../../features/home/HomePage';
import Footer from './Footer';
import NotFoundPage from '../../features/errors/NotFoundPage';
import BadRequestPage from '../../features/errors/BadRequestPage';
import { Container } from 'semantic-ui-react';

function App() {
  return (
    <>
      <NavBar />
      <Route exact path='/' component={HomePage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <>
            <Container style={{ marginTop: '7em' }}>
              <Switch>
                <Route exact path='/moistureContentList' component={MoistureContentList} />
                <Route path='/moistureContentList/:id' component={MoistureContentDetails} />
                <Route path='/notFound' component={NotFoundPage} />
                <Route path='/badRequest' component={BadRequestPage} />
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
