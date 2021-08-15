import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Container, Menu, Image, Dropdown } from 'semantic-ui-react';

export default function NavBar() {

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
                    Spectra QEST
                </Menu.Item>
                <Menu.Item >
                    <Menu.Item >
                        <Dropdown pointing='top left' text='Test Worksheets'>
                            <Dropdown.Menu>
                                <Dropdown.Item text='Moisture Contents List' as={Link} to={`/moistureContentList`} />
                            </Dropdown.Menu>
                        </Dropdown>
                    </Menu.Item>
                </Menu.Item>
                <Menu.Item position='right'>
                    <Image src={'/assets/user.png'} avatar spaced='right' />
                </Menu.Item>

            </Container>
        </Menu>
    )
}