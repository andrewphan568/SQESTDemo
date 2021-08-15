import React from 'react';
import { Button, Item, Segment } from 'semantic-ui-react';
import { MoistureContent } from '../../app/models/apiTypes';

interface Props {
    moistureContents: MoistureContent[];
}

export default function MoistureContentList({ moistureContents }: Props) {
    return (
        <Segment style={{ width: '60%' }}>
            <Item.Group divided>
                {moistureContents.map(moistureContent => (
                    <Item key={moistureContent.id}>
                        <Item.Content>
                            <Item.Header as='a'>{'Project: ' + moistureContent.project?.name}</Item.Header>
                            <Item.Description>
                                <div>{'Water Content (%): ' + moistureContent.waterContentPercentage + ' (%)'}</div>
                                <div>{'Tested By: ' + moistureContent.testerName}</div>
                                <div>{'Date Tested: ' + moistureContent.dateTested}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue' />
                                <Button floated='right' content='Delete' color='red' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}