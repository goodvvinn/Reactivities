import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import { Button, Header, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { useStore } from "../../../app/stores/store";
import { Link } from "react-router-dom";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import MyTextInpun from "../../../app/common/form/MyTextInput";
import MyTextArea from "../../../app/common/form/MyTextArea";
import MySelectInpun from "../../../app/common/form/MySelectInput";
import { categoryOptions } from "../../../app/common/options/categoryOptions";
import MyDateInpun from "../../../app/common/form/MyDateInput";
import { ActivityFormValues } from "../../../app/models/activity";
import { v4 as uuid } from 'uuid'


export default observer(function ActivityForm() {
    const history = useHistory();
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loadActivity, loadingInitial, loading} = activityStore;
    const { id } = useParams<{ id: string }>()
    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());

    const validationSchema = Yup.object({
        title: Yup.string().required('The activity title is required'),
        description: Yup.string().required('The activity description is required'),
        category: Yup.string().required(),
        date: Yup.string().required('Date is required').nullable(),
        city: Yup.string().required(),
        venue: Yup.string().required(),
    })

    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity!)))
    }, [id, loadActivity]);

    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = {
                ...activity,
                id: uuid(),
            };
            createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`))
        } else {
            updateActivity(activity).then(() => history.push(`/activities/${activity.id}`))
        }
    }

    if (loadingInitial) return <LoadingComponent content='Loading activity...' />

    return (
        <Segment clearing>
            <Header content='Activity Details' sub color='teal'/>
            <Formik
                validationSchema={validationSchema}
                enableReinitialize
                initialValues={activity}
                onSubmit={values => handleFormSubmit(values)}>
                {({ handleSubmit, isValid, isSubmitting, dirty  }) => (
                    <Form className="ui form" onSubmit={handleSubmit} >
                        <MyTextInpun name='title' placeholder="Title"/>
                        <MyTextArea rows={3} placeholder="Description" name='description' />
                        <MySelectInpun options={categoryOptions} placeholder="Category" name='category' />
                        <MyDateInpun
                        placeholderText="Date"
                        name='date'
                        showTimeSelect
                        timeCaption='time'
                        dateFormat='MMMM dd yyyy h:mm aa'
                        />
                        <Header content='Location Details' sub color='teal'/>
                        <MyTextInpun placeholder="City" name='city' />
                        <MyTextInpun placeholder="Venue" name='venue' />
                        <Button
                        disabled={isSubmitting || !dirty || !isValid}
                        loading={isSubmitting}
                        floated='right'
                        positive type='submit'
                        content='Submit' />
                        <Button
                        as={Link} 
                        to='/activities' 
                        floated='right' 
                        type='button'
                         content='Cancel' 
                         />
                    </Form>
                )}
            </Formik>
        </Segment>
    )
})