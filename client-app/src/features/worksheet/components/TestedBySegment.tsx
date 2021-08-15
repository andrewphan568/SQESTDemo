import React from 'react';
import {
    Form, Button, Grid, Segment,
} from "semantic-ui-react";

interface Props {
    testerName?: string,
    dateTested?: Date
}

export default function TestedBySegment({ testerName, dateTested }: Props) {
    return (
        <>
            <Segment className="section">
                <Grid columns={2}  >
                    <Grid.Column>
                        <Form.Field>
                            <label>Tested By</label>
                            <p>{testerName}</p>
                        </Form.Field>
                        <Button primary>Clear</Button>
                    </Grid.Column>
                    <Grid.Column>
                        <Form.Field>
                            <label>Date Tested</label>
                            <p>{dateTested}</p>
                        </Form.Field>
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
}