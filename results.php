<?php
    header('Content-Type: text/html; charset=utf-8');
    include_once "config.php";

    if (!$_POST) {
        header('Location: quiz.html');
    }

    //Set CSV Delimiters
    $col_delimiter = ";";
    $row_delimiter = "\r\n";

    $totalPoints = 0;
    $result = "";
    $responses = json_decode($_POST['responses']);
    $responseArr = array();

    foreach ($responses as $q_num => $response) {
        $totalPoints += $conf['questions'][$q_num]['options'][$response]['point'];
        $question_num = explode("_", $q_num)[1];
        $responseArr[] = array(
            'question_num' => $question_num,
            'response'     => $conf['questions'][$q_num]['options'][$response]['opt'],
            'point'        => $conf['questions'][$q_num]['options'][$response]['point'],
        );
    }

    foreach ($conf['results'] as $key => $val) {
        $scoreKey = explode("-", $key);
        if (intval($scoreKey[0]) <= $totalPoints && intval($scoreKey[1]) >= $totalPoints) {
            $result = $val;
        }
    }

    //Create CSV
    $csv = "";
    foreach ($responseArr as $q) {
        $csv .= implode($col_delimiter, $q) . $row_delimiter;
    }

    mkdir("csv", 0700);
    $filename = "csv/csv_" . time() . ".txt";
    $csv_file_name = fopen($filename, "w");
    fwrite($csv_file_name, $csv);
    fclose($csv_file_name);


    //Import Form HTML
    $form = file_get_contents("form.html");
    $form = str_replace("{{Result}}", $result, $form);
    $form = str_replace("{{TOTAL_SCORE}}", $totalPoints, $form);
    echo str_replace("{{CSV}}", $filename, $form);
