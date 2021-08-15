import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Container, Menu, Image, Dropdown, Button } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default function NavBar() {
    const { moistureContentStore } = useStore();
    const { setCreateMode } = moistureContentStore;
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
                <Menu.Item>
                    <Link to='/createMoistureContent'>
                        <Button positive onClick={() => setCreateMode(true)} >
                            Create Moisture Content Worksheet
                        </Button>
                    </Link>
                </Menu.Item>
                <Menu.Item position='right'>
                    <Image src={'/assets/user.png'} avatar spaced='right' />
                </Menu.Item>

            </Container>
        </Menu>
    )
}