using UnityEngine;
using Models;
using Presenter;

public class NutInit : MonoBehaviour
{
    [SerializeField] private RotationView _view;
    [SerializeField] private NutSettings _nutSettings;

    private NutInputRouter _input;
    private Transformable _transformable;
    private TransformablePresenter _presenter;
    private Inertia _inertRotation;

    public Transformable Transformable => _transformable;

    public NutInputRouter Input => _input;

    public Inertia InertRotation => _inertRotation;

    public TransformablePresenter Presenter => _presenter;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (_input != null)
            _input.OnDisable();

        _transformable = new Transformable();
        _inertRotation = new Inertia(_nutSettings);
        _input = new NutInputRouter();
        _presenter = new TransformablePresenter(_transformable, _view);

        _input.OnEnable();
    }
}