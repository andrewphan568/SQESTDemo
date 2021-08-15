import React, { useEffect, useState } from 'react';
import './worksheetStyles.css';
import axios from 'axios';
import {
  Form,
  Radio, Divider,
  Input,
  TextArea,
  Button,
  Icon,
  Select,
  Header,
  Grid,
  Segment
} from "semantic-ui-react";
import { MoistureContentDto } from '../../app/models/apiTypes';
const balanceEquipments = [
  { key: '0', text: 'N/A', value: '' },
  { key: '1', text: '01BAL', value: '01BAL' },
  { key: '2', text: '02BAL', value: '02BAL' },
  { key: '3', text: '03BAL', value: '03BAL' },
];

const ovenEquipments = [
  { key: '0', text: 'N/A', value: '' },
  { key: '1', text: '01OVN', value: '01OVN' },
  { key: '2', text: '02OVN', value: '02OVN' },
  { key: '3', text: '03OVN', value: '03OVN' },
];


const particalSizes = [
  { key: '0', text: 'N/A', value: '' },
  { key: '1', text: '2" (51mm)', value: '2" (51mm)' },
  { key: '2', text: '3" (75mm)', value: '3" (75mm)' },
];
function MoistureContentDetails() {
  // const [moistureContents, setMoistureContents] = useState([]);

  // useEffect(() => {
  //   axios.get('http://localhost:5000/api/moistureContent').then(response => {
  //   console.log(response);
  //   setMoistureContents(response.data.value);
  //   })
  // },[])

  var handleChange = () => {
    return 1;
  }
  const [method, setMethod] = useState("");

  return (
    <>
      <Form className="worksheet">
        <Segment className="section">

          <Grid className="section" columns={3}  >
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
          <Grid className="section" columns={2}  >
            <Grid.Column>
              <Form.Field>
                <label>Project</label>
                <label>Project Code - Project name</label>
              </Form.Field>
              <Form.Field>
                <label>Sampled</label>
                <label>P22-Feb-2019 by Field Tech 1</label>
              </Form.Field>
            </Grid.Column>
            <Grid.Column>
              <Form.Field>
                <label>Source and Material</label>
                <label>Source name here - Material desciption here</label>
              </Form.Field>
              <Form.Field>
                <label>Specification</label>
                <label>Specification name here</label>
              </Form.Field>
            </Grid.Column>
          </Grid>
        </Segment>

        <Header size="small">Preparation</Header>
        <Segment className="section">
          <Grid columns={2}  >
            <Grid.Column>
              <Form.Field>Method:</Form.Field>
              <Form.Field>
                <Radio
                  label="S"
                  name="SelectMethod"
                  value="A"
                  checked={method === "A"}
                  onChange={() => handleChange()}
                />
              </Form.Field>
              <Form.Field>
                <Radio
                  label="B"
                  name="radioGroup"
                  value="B"
                  checked={method === "B"}
                  onChange={() => handleChange()}
                />
              </Form.Field>

              <Form.Input fluid label='Drying temperature (oC)' />
              <Form.Select fluid label='Balance:' options={balanceEquipments} />

            </Grid.Column>
            <Grid.Column>
              <Form.Select fluid label='Visual Nominal Particle Size:' options={particalSizes} />
              <Form.Checkbox label='Material Excluded' />
              <Form.Input fluid disabled={true} />
              <Form.Select fluid label='Oven:' options={ovenEquipments} />
            </Grid.Column>
          </Grid>
        </Segment>

        <Header size="small">Measurements</Header>
        <Segment className="section">
          <Grid columns={2}  >
            <Grid.Column>
              <Form.Input fluid label='Tare ID:' />
              <Form.Input fluid label='Tare and Material Wet Mass(g):' />
            </Grid.Column>
            <Grid.Column>
              <Form.Input fluid label='Tare Mass (g):' />
              <Form.Input fluid label='Material Wet Mass(g):' />
            </Grid.Column>
          </Grid>
        </Segment>

        <Header size="small">Dry Mass</Header>
        <Segment className="section">
          <Grid columns={2}  >
            <Grid.Column>
              <Form.Select fluid label='Balance:' options={balanceEquipments} />
              <Form.Input fluid label='Tare and Material Dry Mass(g):' />
            </Grid.Column>
            <Grid.Column>
              <Form.Field>
                <label>Material Dry Mass(g)</label>
                <label>2225.7</label>
              </Form.Field>
            </Grid.Column>
          </Grid>
        </Segment>

        <Header size="small">Results</Header>
        <Segment className="section">
          <Grid className="section" columns={2}  >
            <Grid.Column>
              <Form.Field>
                <label>Water Content (%)</label>
                <label>15.0%</label>
              </Form.Field>
              <Header size="small">Report</Header>
              <Form.Checkbox label='Insufficient Sample Mass' />
              <Form.Checkbox label='Drying Temperature' />
              <Form.Checkbox label='Material Excluded' />
            </Grid.Column>
          </Grid>
        </Segment>

        <Header size="small">Remarks</Header>
        <Segment className="section">
          <TextArea style={{ minHeight: 100 }} />
          <Header size="small">Review</Header>
          <Grid className="section" columns={2}  >
            <Grid.Column>
              <Form.Field>
                <label>Checked By</label>
                <label>Andrew Phan</label>
              </Form.Field>
            </Grid.Column>
            <Grid.Column>
              <Form.Field>
                <label>Date Checked</label>
                <label>04-Sep-2018</label>
              </Form.Field>
            </Grid.Column>
          </Grid>
        </Segment>

        <Form.Button content='Clear' />
      </Form>
    </>
  );
}

export default MoistureContentDetails;
