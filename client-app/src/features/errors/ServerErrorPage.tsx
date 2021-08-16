import React from 'react';
import { Link } from 'react-router-dom';
import { Header, Icon, Segment } from 'semantic-ui-react';

export default function SeverErrorPage() {
    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='server' />
                Oops -Five Oh Oh - Server Error.
            </Header>

            <Segment.Inline>
                <h3>Return to <Link to='/moistureContentList'>the Moisture Content Worksheet List page</Link></h3>
            </Segment.Inline>
        </Segment>
    )
}