import "./Profile.css"
import React, {useState} from 'react';
import CustomAccordion from "../../shared/customAccordion/CustomAccordion";
import {IconButton} from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
import {useStyles} from "../../../utils/CssClasses";
import useFetchAll from "../../../services/useFetchAll";



const Profile = (props) => {

    const {user, updateUser} = props

    const urls = user.map((obj) => `/user/${obj.id}`);

    const {data: users, loading, error} = useFetchAll(urls);

    const classes = useStyles();







    if (loading) return <h1>Loading ...</h1>
    if (error) return <h1>Tutto ok bro</h1>
        return (
        <>

            <div className={"profile"}>
                <div className={"image"}>

                </div>
                <h6>#ID:</h6>
                <h3>Username:</h3>
                <input />
                <h5>Email:</h5>
                <div>
                    <IconButton  id={"add"} aria-label="Add">
                        <AddIcon />
                    </IconButton>
                    Add a post
                </div>

                <div id={"totalPanel"} className={classes.root}>

                    <CustomAccordion/>

                </div>

            </div>
        </>
    );
}

export default Profile;