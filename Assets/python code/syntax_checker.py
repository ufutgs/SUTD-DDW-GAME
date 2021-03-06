
import UnityEngine
import traceback,timeit
cube = UnityEngine.GameObject.FindGameObjectsWithTag("sequence")[0].transform
sequence_array = [] # primary list for random and sorting 
backup = [] # original randomized list
cube_list=[] #GUI cube list
backup_cube=[] # original randomized cube position
def move_cube(): # move the cube list from randomized to ordered 
    global sequence_array,cube_list,backup,backup_cube
    i=0
    for element_cube in cube_list:
        index = sequence_array.index(backup[i])
        element_cube.position = backup_cube[index]
        i+=1

def init():# yup, is just init
    global sequence_array,cube,cube_list,backup,backup_cube
    file= open("Assets/python code/sequence.txt","r")
    str = file.read()
    sequence_array = str.split(",")
    i=0
    for element_cube in cube:
        sequence_array[i] = int(sequence_array[i])
        cube_list.append(element_cube)
        backup_cube.append(element_cube.position)
        i+=1
    backup = sequence_array.copy()
    file.close()

def print_ans(arr):
    a=""
    for i in arr:
        a+=str(i)+","
    return a[:-1]

init()
code = open("Assets/python code/code.txt","r") # read user input 
try:# try code and other function
    current_time = timeit.default_timer()
    exec(code.read())
    stop_time = timeit.default_timer()
    time_result = stop_time-current_time
    code.close()
    move_cube()
    result = open("Assets/python code/result.txt","w")
    result.write(print_ans(sequence_array)+"@"+str(time_result*1000))
    result.close()
except Exception as e : # report exception
    UnityEngine.Debug.Log('something went wrong in python side!')
    UnityEngine.Debug.Log(traceback.format_exc())
    code.close()

	