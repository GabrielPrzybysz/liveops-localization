import json
import urllib3
import boto3


CSV_DOWNLOAD_LINK = "https://docs.google.com/spreadsheets/d/1oPHVXfKkpgaVLGNyQ7p-MyychZytXecblO4YGkBc1dM/gviz/tq?tqx=out:csv"
BUCKET_NAME = 'yourgame-localization'
FILE_NAME = 'localization.csv'


def lambda_handler(event, context):

    try:
        create_file_in_s3()
        return {
            'statusCode': 200,
            'body': json.dumps('File created successfully!')
        }
    except:
        return {
            'statusCode': 501,
            'body': json.dumps('Error to create file')
        }


def download_csv():

    http = urllib3.PoolManager()

    resp = http.request("GET", CSV_DOWNLOAD_LINK)

    return resp.data


def create_file_in_s3():

    binary_csv = download_csv()
    s3 = boto3.resource("s3")
    s3.Bucket(BUCKET_NAME).put_object(ACL='public-read-write', Key=FILE_NAME, Body=binary_csv)

