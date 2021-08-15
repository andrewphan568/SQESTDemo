import React from 'react';
import {
    Header, Form, Divider, Icon, Button, Grid, Segment,
} from "semantic-ui-react";

interface Props {
    projectCode?: string,
    projectName?: string,
    sampledDate?: Date,
    sampledBy?: string,
    sourceMaterialName?: string,
    sourceMaterialDesciption?: string,
    specificationName?: string,
}

export default function TestSubjectSegment({ projectCode, projectName, sampledDate, sampledBy, sourceMaterialName,
    sourceMaterialDesciption, specificationName }: Props) {
    return (
        <>
            <Segment className="section">
                <Grid columns={3}  >
                    <Grid.Column>
                        <Header as='h4' floated='left'> EST-WOOOO1-S1  </Header>
                    </Grid.Column>
                    <Grid.Column>
                        <Header as='h4'> ASTM D2216 - 2017 </Header>
                    </Grid.Column>
                    <Grid.Column>
                        <Button icon labelPosition='right' floated='right'>Changes Saved
                            <Icon name='undo' />
                        </Button>
                    </Grid.Column>
                </Grid>
                <Divider />

                <h4> Water (Moisture) Content of Soil and Rock by Mass</h4>
                <Grid columns={2}  >
                    <Grid.Column>
                        <Form.Field>
                            <label>Project</label>
                            <p>{projectCode + ' - ' + projectName}</p>
                        </Form.Field>
                        <Form.Field>
                            <label>Sampled</label>
                            <p>{sampledDate + ' by ' + sampledBy}</p>
                        </Form.Field>
                    </Grid.Column>
                    <Grid.Column>
                        <Form.Field>
                            <label>Source and Material</label>
                            <p>{sourceMaterialName + ' - ' + sourceMaterialDesciption}</p>
                        </Form.Field>
                        <Form.Field>
                            <label>Specification</label>
                            <p>{specificationName}</p>
                        </Form.Field>
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
}