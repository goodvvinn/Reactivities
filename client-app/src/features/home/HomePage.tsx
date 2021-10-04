import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";

export default observer(function HomePage() {
    const { userStore, modalStore } = useStore();
    return (
        <Segment inverted vertical className="masthead">
            <Container text>
                <Header as='h1' inverted textAlign='center'>
                    <Image size='massive' src='/assets/logo.png' style={{ marginBottom: 12 }} />
                    Reactivities
                </Header >
                {userStore.isLoggedIn ? (
                    <>
                        <Header as='h2' textAlign='center' inverted content='Welcome to Reactivities!' />
                        <Button textAlign='center' as={Link} to='/activities' size='huge' inverted>
                            Go to Activities!!!
                        </Button>
                    </>
                ) : (
                    <>
                        <Button onClick={() => modalStore.openModal(<LoginForm />)} size='huge' inverted>
                            Login
                        </Button>
                        <Button onClick={() => modalStore.openModal(<RegisterForm />)} size='huge' inverted>
                            Register
                        </Button>
                    </>
                )}
            </Container>
        </Segment>
    )
})