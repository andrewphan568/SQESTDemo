import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Button, Item, Segment } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponent from '../../app/layout/LoadingComponent';

export default observer(function MoistureContentList() {
    const { moistureContentStore } = useStore();
    const { loadMoistureContents, moistureContents } = moistureContentStore;

    useEffect(() => {
        if (moistureContents.length === 0) loadMoistureContents();
    }, [moistureContents.length, loadMoistureContents])

    if (moistureContentStore.loading) return <LoadingComponent content='Loading worksheets...' />

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
                                <Button as={Link} to={`/moistureContentList/${moistureContent.id}`} floated='right' content='View' color='blue' />
                                <Button floated='right' content='Delete' color='red' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})