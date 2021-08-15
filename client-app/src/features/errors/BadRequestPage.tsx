import React from 'react';
import { Link } from 'react-router-dom';
import { Header, Icon, Segment } from 'semantic-ui-react';

export default function BadRequestPage() {
    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                Oops - Four Oh Oh - Bad Request.
            </Header>

            <Segment.Inline>
                <h3>Return to <Link to='/moistureContentList'>the Moisture Content Worksheet List page</Link></h3>
            </Segment.Inline>
        </Segment>
    )
}