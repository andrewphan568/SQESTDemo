import React from 'react';
import {
    Form, Button, Grid, Segment,
} from "semantic-ui-react";
import { observer } from 'mobx-react-lite';
import moment from 'moment'

interface Props {
    testerName?: string,
    dateTested?: Date,
    editModeOrCreateMode?: boolean;
    changeInfo: (newValue: any, key: string, extraKey?: string) => void;
    clear: () => void;
}

export default observer(function TestedBySegment({ testerName, dateTested, editModeOrCreateMode, changeInfo, clear }: Props) {
    return (
        <>
            {!editModeOrCreateMode &&
                <Segment className="section">
                    <Grid columns={2}  >
                        <Grid.Column>
                            <Form.Field>
                                <label>Tested By</label>
                                <p>{testerName}</p>
                            </Form.Field>
                            <Button primary disabled={!editModeOrCreateMode} onClick={() => clear()} >Clear </Button>
                        </Grid.Column>
                        <Grid.Column>
                            <Form.Field>
                                <label>Date Tested</label>
                                <p>{dateTested}</p>
                            </Form.Field>
                        </Grid.Column>
                    </Grid>
                </Segment>
            }

            {editModeOrCreateMode &&
                <Segment className="section">
                    <Grid columns={2}  >
                        <Grid.Column>
                            <Form.Input fluid label="Tested By" value={testerName ?? ""}
                                onChange={(e) => changeInfo(e.target.value, "testerName", "TestedBySegment")}
                            />
                            <Button primary disabled={!editModeOrCreateMode} onClick={() => clear()} >Clear </Button>
                        </Grid.Column>
                        <Grid.Column>
                            <Form.Input fluid type='date' label="Date Tested" value={dateTested ? moment(dateTested).format('yyyy-MM-DD') : undefined}
                                onChange={(e) => changeInfo(e.target.value, "dateTested", "TestedBySegment")}
                            />
                        </Grid.Column>
                    </Grid>
                </Segment>
            }
        </>
    )
})