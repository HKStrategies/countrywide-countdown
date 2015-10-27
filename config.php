<?php
    $conf['questions'] = array(
        'q_1' => array(
            'question'  => 'On a Saturday what are you most likely to be doing?',
            'options'   => array(
                array('opt' => 'Spend the day in bed watching Spooks', 'point' => 0),
                array('opt' => 'Reading the newspaper?', 'point' => 1),
                array('opt' => 'Cycling blindfolded down Ben Nevis?', 'point' => 2),
                array('opt' => 'Volunteering at the local Youth Club?', 'point' => 3),
            ),
            'rationale' => array(
                array('opt' => 'Slack'),
                array('opt' => 'Inquisitive/Worldly Wide'),
                array('opt' => 'Adventurer/Risk Taker'),
                array('opt' => 'Selfless'),
            ),

        ),
        'q_2' => array(
            'question'  => 'Your planning a holiday, what is your trip of choice?',
            'options'   => array(
                array('opt' => 'Lying on the beach for the week?', 'point' => 0),
                array('opt' => 'Exploring the long lost cities of China? ', 'point' => 2),
                array('opt' => 'Snowboarding in the Rockies?', 'point' => 2),
                array('opt' => 'Building a school in Burma?', 'point' => 2),
            ),
            'rationale' => array(
                array('opt' => 'Slack'),
                array('opt' => 'Inquisitive/Worldly Wide'),
                array('opt' => 'Adventurer/Risk Taker'),
                array('opt' => 'Selfless'),
            ),
        ),
        'q_3' => array(
            'question'  => 'Which of these qualities best describes you?',
            'options'   => array(
                array('opt' => 'Good Listener', 'point' => 1),
                array('opt' => 'Relentlessly Positive', 'point' => 1),
                array('opt' => 'Skilled Multi-tasker', 'point' => 1),
                array('opt' => 'Brilliant Communicator', 'point' => 1),
            ),
            'rationale' => array(
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
            ),
        ),
        'q_4' => array(
            'question'  => 'If you could be a character in history who would you be?',
            'options'   => array(
                array('opt' => 'William the Conquerer', 'point' => 0),
                array('opt' => 'Elizabeth !', 'point' => 3),
                array('opt' => 'John Lennon', 'point' => 1),
                array('opt' => 'Alexander Fleming', 'point' => 2),
            ),
            'rationale' => array(
                array('opt' => 'Conquer and rule'),
                array('opt' => 'Visionary/Selfless/Putting your team (country) first.'),
                array('opt' => 'Musican but not far reaching'),
                array('opt' => 'Dedicated life to medicine'),
            ),
        ),
        'q_5' => array(
            'question'  => 'Which Countrywide value most represents you?',
            'options'   => array(
                array('opt' => 'Responsible', 'point' => 1),
                array('opt' => 'Personable', 'point' => 1),
                array('opt' => 'Straightforward', 'point' => 1),
                array('opt' => 'Passionate', 'point' => 1),
            ),
            'rationale' => array(
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
                array('opt' => 'All equal so score 1 point,just need to get values in'),
            ),
        ),
        'q_6' => array(
            'question'  => 'When faced with a challenge what do you do?',
            'options'   => array(
                array('opt' => 'Hide in the corner and hope someone else can deal with it?', 'point' => 0),
                array('opt' => 'Come up with a solution on your own.', 'point' => 1),
                array('opt' => 'Rally the troops - more heads are better than one', 'point' => 3),
                array('opt' => 'Take immediate action?', 'point' => 2),
            ),
            'rationale' => array(
                array('opt' => 'Shys away from responsibility'),
                array('opt' => 'Great, but better to work as a team'),
                array('opt' => 'Collaborative approach'),
                array('opt' => 'Hot headed'),
            ),
        ),
        'q_7' => array(
            'question'  => 'If you were a special agent who would you be?',
            'options'   => array(
                array('opt' => 'Jason Bourne', 'point' => 0),
                array('opt' => 'James Bond', 'point' => 2),
                array('opt' => 'Sherlock Holmes', 'point' => 3),
                array('opt' => 'Agent Cody Banks', 'point' => 1),
            ),
            'rationale' => array(
                array('opt' => 'Renegade'),
                array('opt' => 'Well liked and serves his country'),
                array('opt' => 'Methodical'),
                array('opt' => 'Comedy character'),
            ),
        ),
        'q_8' => array(
            'question'  => 'You\'ve been set a task with a tight deadline. What do you do first?    ',
            'options'   => array(
                array('opt' => 'Go for lunch - you need to eat first.', 'point' => 0),
                array('opt' => 'Write a list of what needs to be done and then assign tasks.', 'point' => 3),
                array('opt' => 'Delegate workload to your team', 'point' => 2),
                array('opt' => 'Get out of the office and go for a walk - ARGGGHHHH', 'point' => 0),
            ),
            'rationale' => array(
                array('opt' => 'Selfish'),
                array('opt' => 'Methodical approach'),
                array('opt' => 'Good but needs some structure'),
                array('opt' => 'not able to prioritise'),
            ),
        ),
    );

    $conf['results'] = array(
        '0-8'   => 'Some interesting answers there. We’re curious to know more please fill in the form below to apply.',
        '9-15'  => 'We can see real potential in those answers, please fill in the form below to apply.',
        '16-24' => 'Wow! Those are some impressive responses. You are clearly the type of person we’re looking for! Fill in the form below to apply.'
    );