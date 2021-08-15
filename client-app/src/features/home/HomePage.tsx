import React from 'react';
import { Link } from 'react-router-dom';
import { Container } from 'semantic-ui-react';

export default function HomePage() {
    return (
        <Container style={{ marginTop: '7em', minHeight: '80vh' }}>
            <h1>Welcome to S-QEST Code Challenge App</h1>
            <h3>Go to <Link to='/moistureContentList'>Moisture Content Worksheet List</Link></h3>
        </Container>
    )
}