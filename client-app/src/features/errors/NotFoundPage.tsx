import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Header, Icon, Segment } from 'semantic-ui-react';

export default function NotFoundPage() {
    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                Oops - Four Oh Four - Not Found.
            </Header>
            <Segment.Inline>
                <Button as={Link} to='/moistureContentList' primary>
                    Return to the Moisture Content Worksheet List page
                </Button>
            </Segment.Inline>
        </Segment>
    )
}