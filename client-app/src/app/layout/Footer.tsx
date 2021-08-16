import React from 'react';
import { Container, Divider, List, Image } from 'semantic-ui-react';

export default function Footer() {
    return (
        <Container textAlign='center' style={{ margin: '10px' }}>
            <Divider inverted />
            <Image centered size='mini' src='/assets/logo.png' />
            <List horizontal divided link size='small'>
                <List.Item as='a' href='#'>
                    Site Map
                </List.Item>
                <List.Item as='a' href='#'>
                    Contact Us
                </List.Item>
                <List.Item as='a' href='#'>
                    Terms and Conditions
                </List.Item>
                <List.Item as='a' href='#'>
                    Privacy Policy
                </List.Item>
            </List>
        </Container>

    )
}