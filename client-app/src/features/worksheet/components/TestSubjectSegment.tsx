import React from 'react';
import {
    Header, Form, Divider, Icon, Button, Grid, Segment,
} from "semantic-ui-react";
import { StandardTestMethod } from '../../../app/models/apiTypes';

interface Props {
    worksheetId?: string;
    standardTestMethod?: StandardTestMethod;
    projectCode?: string,
    projectName?: string,
    sampledDate?: Date,
    sampledBy?: string,
    sourceMaterialName?: string,
    sourceMaterialDesciption?: string,
    specificationName?: string,
}

export default function TestSubjectSegment({ projectCode, projectName, sampledDate, sampledBy, sourceMaterialName,
    sourceMaterialDesciption, specificationName, worksheetId, standardTestMethod }: Props) {
    return (
        <>
            <Segment className="section">
                <Grid columns={3}  >
                    <Grid.Column>
                        <Header as='h4' floated='left'> {worksheetId ?? ""}  </Header>
                    </Grid.Column>
                    <Grid.Column>
                        <Header as='h4'> {standardTestMethod?.code ?? ""} </Header>
                    </Grid.Column>
                    <Grid.Column>
                        <Button icon labelPosition='right' floated='right'>Changes Saved
                            <Icon name='undo' />
                        </Button>
                    </Grid.Column>
                </Grid>
                <Divider />

                <Header as='h2' style={{ textAlign: 'center' }} >{standardTestMethod?.name ?? ""}</Header>

                <Grid columns={2}  >
                    <Grid.Column>
                        <Form.Field>
                            <label>Project</label>
                            {projectCode && projectName &&
                                <p>{projectCode + ' - ' + projectName}</p>
                            }
                        </Form.Field>
                        <Form.Field>
                            <label>Sampled</label>
                            {sampledDate && sampledBy &&
                                <p>{sampledDate + ' by ' + sampledBy}</p>
                            }
                        </Form.Field>
                    </Grid.Column>
                    <Grid.Column>
                        <Form.Field>
                            <label>Source and Material</label>
                            {sourceMaterialName && sourceMaterialDesciption &&
                                <p>{sourceMaterialName + ' - ' + sourceMaterialDesciption}</p>
                            }
                        </Form.Field>
                        <Form.Field>
                            <label>Specification</label>
                            {specificationName &&
                                <p>{specificationName}</p>
                            }
                        </Form.Field>
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
}