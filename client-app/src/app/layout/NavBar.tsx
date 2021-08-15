import React from 'react';
import { Container, Menu, Image, Dropdown } from 'semantic-ui-react';

export default function NavBar() {

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
                    Spectra QEST
                </Menu.Item>
                <Menu.Item >
                    <Menu.Item >
                        <Dropdown pointing='top left' text='Worksheets'>
                            <Dropdown.Menu>
                                <Dropdown.Item text='Moisture Contents' />
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