using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Developor
{
    MoviePart CreateMoviePart(string _part){}
}

public abstract class MoviePart
{
    
}

public class Movie
{

}

public class Audience
{
    void WatchMovie(Movie _movie);
}


public class Script : MoviePart
{

}

public class CharactorDesign : MoviePart
{

}

public class SceneDesign : MoviePart
{
    
}

public class Animation : MoviePart
{
    
}

public class Music : MoviePart
{
    
}

public class Score : MoviePart
{
    
}

public class Director
{
    MoviePart m_Script;
    MoviePart m_CharactorDesign;
    MoviePart m_SceneDesign;
    MoviePart m_Animation;
    MoviePart m_Music;
    MoviePart m_Score;
    
    Movie CreateMovie(MoviePart[] _parts){}
}



