import React from 'react';
import {
    Form, Header, Grid, Segment,
} from "semantic-ui-react";
import { observer } from 'mobx-react-lite';

interface Props {
    waterContentPercentage?: number,
    insufficientSampleMass?: boolean,
    dryingTemperature?: boolean,
    materialExcluded?: boolean,
    changeInfo: (newValue: any, key: string, extraKey?: string) => void
}

export default observer(function ResultsSegment({ waterContentPercentage, insufficientSampleMass, dryingTemperature, materialExcluded, changeInfo }: Props) {
    return (
        <>
            <Header size="small">Results</Header>
            <Segment className="section">
                <Grid className="section" columns={2}  >
                    <Grid.Column>
                        <Form.Field>
                            <label>Water Content (%)</label>
                            <p>{waterContentPercentage ? waterContentPercentage.toFixed(2) + "%" : "N/A"}</p>
                        </Form.Field>
                        <Header size="small">Report</Header>
                        <Form.Checkbox label='Insufficient Sample Mass' checked={insufficientSampleMass}
                            onChange={(e, value) => changeInfo(value, "selectInsufficientSampleMass", "ResultsSegment")} />
                        <Form.Checkbox label='Drying Temperature' checked={dryingTemperature}
                            onChange={(e, value) => changeInfo(value, "selectDryingTemperature", "ResultsSegment")} />
                        <Form.Checkbox label='Material Excluded' checked={materialExcluded}
                            onChange={(e, value) => changeInfo(value, "selectMaterialExcluded", "ResultsSegment")} />
                    </Grid.Column>
                </Grid>
            </Segment>
        </>
    )
})